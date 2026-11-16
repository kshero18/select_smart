var app = angular.module('cps', ['angularjs-dropdown-multiselect']);
app.controller('multiselectdropdown', ['$scope', '$http', function ($scope, $http) {
    //define object 
    $scope.CategoriesSelected = [];
    $scope.Categories = [];
    $scope.dropdownSetting = {
        scrollable: true,
        scrollableHeight: '200px'
    }
    //fetch data from database for show in multiselect dropdown
    $http.get('/home/getcategories').then(function (data) {
        angular.forEach(data.data, function (value, index) {
            $scope.Skills.push({ id: value.Id, label: value.skills });
        });
    })
    //post or submit selected items from multiselect dropdown to server
    $scope.SubmittedCategories = [];
    $scope.SubmitData = function () {
        var categoryIds = [];
        angular.forEach($scope.CategoriesSelected, function (value, index) {
            categoryIds.push(value.id);
        });

        var data = {
            categoryIds: categoryIds
        };

        $http({
            method: "POST",
            url: "/home/savedata",
            data: JSON.stringify(data)
        }).then(function (data) {
            $scope.SubmittedCategories = data.data;
        }, function (error) {
            alert('Error');
        })
    }
}])