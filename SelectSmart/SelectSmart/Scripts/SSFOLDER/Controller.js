<reference path="../angular.js">


<reference path="Module.js">
//The controller is having 'crudService' dependency.
//This controller makes call to methods from the service 
app.controller('crudController', function ($scope, crudService) {

    $scope.IsNewRecord = 1; //The flag for the new record

    loadRecords();

    //Function to load all Employee records
    function loadRecords() { var promiseGet = crudService.getCandidate(); //The MEthod Call from service

        promiseGet.then(function (pl) { $scope.Candidate = pl.data },
            function (errorPl) {
                $log.error('failure loading Candidate', errorPl);
            });
    }

    //The Save scope method use to define the Employee object.
    //In this method if IsNewRecord is not zero then Update Employee else 
    //Create the Employee information to the server
    $scope.save = function () {
        var Candidate = {
            Regno: $scope.Regno,
            Name: $scope.Name,
            Email: $scope.Email,
            Phoneno: $scope.Phoneno,
            Dept: $scope.Dept,
            skills: $scope.skills,
            Yearofpassing: $scope.Yearofpassing,
            CGPA: $scope.CGPA,
            Backlogs: $scope.Backlogs
        };
        //If the flag is 1 the it si new record
        if ($scope.IsNewRecord === 1) {
            var promisePost = crudService.post(Candidate);
            promisePost.then(function (pl) {
                $scope.Regno = pl.data.Regno;
                loadRecords();
            }, function (err) {
                console.log("Err" + err);
            });
        } else { //Else Edit the record
            var promisePut = crudService.put($scope.Regno, Candidate);
            promisePut.then(function (pl) {
                $scope.Message = "Updated Successfuly";
                loadRecords();
            }, function (err) {
                console.log("Err" + err);
            });
        }



    };

    //Method to Delete
    $scope.delete = function () {
        var promiseDelete = crudService.delete($scope.Regno);
        promiseDelete.then(function (pl) {
            $scope.Message = "Deleted Successfuly";
            $scope.Regno = "";
            $scope.Name = "";
            $scope.Email = "";
            $scope.Phoneno = 0;
            $scope.Dept = "";
            $scope.skills = "";
            $scope.Yearofpassing = 0;
            $scope.CGPA = 0;
            $scope.Backlogs = 0;
            loadRecords();
        }, function (err) {
            console.log("Err" + err);
        });
    }

    //Method to Get Single Candidate based on Regno
    $scope.get = function (Candidate) {
        var promiseGetSingle = crudService.get(Candidate.Regno);

        promiseGetSingle.then(function (pl) {
            var res = pl.data;
            $scope.Regno = res.Regno;
            $scope.Name = res.Name;
            $scope.Email = res.Email;
            $scope.Phoneno = res.Phoneno;
            $scope.Dept = res.Dept;
            $scope.skills = res.skills;
            $scope.Yearofpassing = res.Yearofpassing;
            $scope.CGPA = res.CGPA;
            $scope.Backlogs = res.Backlogs;
          
            $scope.IsNewRecord = 0;
        },
            function (errorPl) {
                console.log('failure loading Candidate', errorPl);
            });
    }
    //Clear the Scopr models
    $scope.clear = function () {
        $scope.IsNewRecord = 1;
        $scope.Regno = "";
        $scope.Name = "";
        $scope.Email = "";
        $scope.Phoneno = 0;
        $scope.Dept = "";
        $scope.skills = "";
        $scope.Yearofpassing = 0;
        $scope.CGPA = 0;
        $scope.Backlogs = 0;
    }
});

</reference ></reference >