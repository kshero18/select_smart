<reference path="../angular.js">
<reference path="Module.js">


app.service('crudService', function ($http) {


    //Create new record
    this.post = function (Candidate) {
        var request = $http({
            method: "post",
            url: "/api/CandidateAPI",
            data: Candidate
        });
        return request;
    }
    //Get Single Records
    this.get = function (Regno) {return $http.get("/api/CandidateAPI/" + Regno);}

    //Get All Employees
    this.getCandidate = function () {
        return $http.get("/api/CandidateAPI");
    }


    //Update the Record
    this.put = function (Regno, Candidtate) {
        var request = $http({
            method: "put",
            url: "/api/CandidtateAPI/" + RegNo,
            data: Candidtate
        });
        return request;
    }
    //Delete the Record
    this.delete = function (Regno) {
        var request = $http({
            method: "delete",
            url: "/api/CandidtateAPI/" + Regno
        });
        return request;
    }
});
 
</reference ></reference >