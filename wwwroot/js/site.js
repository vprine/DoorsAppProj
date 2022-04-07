// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



var myApp = angular.module('doorsApp', []);

// Define the `PhoneListController` controller on the `phonecatApp` module
myApp.controller("DoorsController", function($scope, $timeout, DoorService) {  
    $scope.dvDoor = false;  
    GetDoorList();
    Polling();
    $scope.doors = [];

    $scope.new_door = { GivenName: "New name", Id: 0, IsClosed: false, IsLocked: false };


    function Polling () {

        (function tick() {
            
                DoorService.getAllDoors().then(function (stu) {
                    $scope.doors = stu.data;
                    $timeout(tick, 10000);
                }, function () {
                    alert('Error in getting records');
                });
                
            
        })();
    };


    //To Get All Records  
    function GetDoorList() {  
        DoorService.getAllDoors().then (function(stu) {  
            $scope.doors = stu.data;  
        },function() {  
            alert('Error in getting records');  
        });  
    }  
    // To display Add div  
    $scope.AddNewDoor = function() {  
            $scope.Action = "Add";  
            $scope.dvDoor = true;  
        }  
        // Adding New door record  
    $scope.AddDoor = function(door) {  
            DoorService.AddNewDoor(door).then(function(msg) {  
                $scope.doors.push(msg.data);
                $scope.dvAddDoor = false;  
            }, function() {  
                alert('Error in adding record');  
            });  
        }  
        // Deleting record.  
    $scope.deleteDoor = function(stu, index) {  
            var retval = DoorService.deleteDoor(stu).then(function(msg) {  
                $scope.doors.splice(index, 1);  
                // alert('Door has been deleted successfully.');  
            }, function() {  
                alert('Oops! something went wrong.');  
            });  
        }  
        // Updateing Records  
    $scope.UpdateDoor = function(tbl_Door) {  
        var RetValData = DoorService.UpdateDoor(tbl_Door);  
        getData.then(function(tbl_Door) {  
            Id: $scope.Id;  
            DoorName: $scope.doorName;  
            DoorAddress: $scope.DoorAddress;  
            DoorEmail: $scope.DoorEmail;  
        }, function() {  
            alert('Error in getting records');  
        });  
    }  
});

myApp.service("DoorService", function ($http) {
    //get All Eployee  
    this.getAllDoors = function () {
        return $http.get("Door/GetDoorList");
    };
    // Adding Record  
    this.AddNewDoor = function (tbl_Door) {
        return $http({
            method: "post",
            url: "Door/AddDoor",
            data: JSON.parse(angular.toJson(tbl_Door)),
            dataType: "json"
        });
    }
    // Updating record  
    this.UpdateDoor = function (tbl_Door) {
        return $http({
            method: "post",
            url: "Door/UpdateDoor",
            data: JSON.parse(angular.toJson(tbl_Door)),
            dataType: "json"
        });
    }
    // Deleting records  
    this.deleteDoor = function (tbl_Door) {
        return $http({
            method: "post",
            url: "Door/DeleteDoor",
            data: JSON.parse(angular.toJson(tbl_Door)),
            dataType: "json"
        });
    }
});