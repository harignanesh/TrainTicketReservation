/// <reference path="angular-1.7.2/angular.js" />

var App = angular.module('beginReservation', []);
App.directive('onlyDigits', function () {
    return {
        require: 'ngModel',
        restrict: 'A',
        link: function (scope, element, attr, ctrl) {
            function inputValue(val) {
                if (val) {
                    var digits = val.replace(/[^0-9]/g, '');

                    if (digits !== val) {
                        ctrl.$setViewValue(digits);
                        ctrl.$render();
                    }
                    return parseInt(digits, 10);
                }
                return undefined;
            }
            ctrl.$parsers.push(inputValue);
        }
    };
});
App.directive('onlyCharacters', function () {
    return {
        require: 'ngModel',
        restrict: 'A',
        link: function (scope, element, attr, ctrl) {
            function inputValue(val) {
                if (val) {
                    var digits = val.replace(/[^a-zA-Z]/g, '');
                    console.log(digits);
                    if (digits !== val) {
                        ctrl.$setViewValue(digits);
                        ctrl.$render();
                    }
                    return val;
                }
                return undefined;
            }
            ctrl.$parsers.push(inputValue);
        }
    }

});

App.controller('bookingController', function ($scope, $http) {



    function init() {
        $scope.selectedPlace;
        $scope.RandNumber();
        $scope.place = [{ Name: 'Chennai', Price: '150' }, { Name: 'Bangalore', Price: '250' }, { Name: ' Madurai', Price: '200' }, { Name: 'Delhi', Price: '350' } ];
    }
    $scope.Calculate = function () {
        //alert($scope.MyData);
        //var p = angular.element(document.getElementById("cost"));
        $scope.totalCost = $scope.unitPrice * $scope.Numberofpassenger;
    }

    $scope.priceforPlace = function (value) {
        angular.forEach($scope.place, function (item){
            if (item.Name === value) {
                $scope.unitPrice = item.Price;
            }
        })


    };

    $scope.Save = function () {

        // alert("enter Save fn");
        var Userdata = { EmailID: $scope.EmailId, TicketNumber: $scope.TicketNumber, Price: $scope.unitPrice, NumberOfPassenger: $scope.Numberofpassenger, TotalCost: $scope.totalCost, DateofTravel: $scope.DateofTravel, BookedBY: $scope.BookedBY, Place: $scope.Place };
        //validate();
        console.log(Userdata);
        $http({
            url: "http://localhost:56301/TrainWebService/api/TR",
            dataType: 'json',
            method: 'POST',
            contentType: "application/json",
            data: Userdata,
        }).then(function (data, status, headers, config) {
            $scope.msg = "Ticket Booked!! Have A Safe Journey";
            },function error(response) {
                $scope.msg = 'Something Went Wrong !!! Try again..';
        });
        //alert("end Save fn");


    }
    $scope.Date = function () {

        this.DateofTravel = new Date();
        this.isOpen = false;
    }
    $scope.RandNumber = function () {
        var number = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
        $scope.TicketNumber = Math.round(Math.random(number) * 10000000);

    }

    $scope.ValidateEmail = function (mail) {
        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
            return (true);
        }
        alert("You have entered an invalid email address!")
        return (false);
    }

    init();
});

