(function () {
    'use strict'

    angular
    .module('app')
    .factory('StudentService', StudentService);

    function StudentService($http, $q, ApiConfiguration) {

        var serviceUrl = ApiConfiguration.serviceUrl;
        var studentServiceFactory = {};
        

        var _getAllGrades = function () {
            //create deferred object
            var deferred = $q.defer();

            //service call
            $http.get(serviceUrl + "api/Grades").success(function (response) {

                deferred.resolve(response);
            })
            .error(function (errorMessage, status) {

                deferred.reject(errorMessage);
            });

            return deferred.promise;
        }

        var _saveStudentProfile = function(studentDetails)
        {
            // do API call 
            var deferred = $q.defer();

            $http.defaults.headers.post['Content-Type'] = 'application/json';

            // http post call 
            $http.post(serviceUrl + "api/students/savestudent/", studentDetails).success(function (response) {

                deferred.resolve(response);

            }).error(function (err, status) {

                deferred.reject(err);
            });
            return deferred.promise;
        }

        var _updateStudentProfile = function (studentDetails) {
            // do API call 
            var deferred = $q.defer();

            // http post call 
            $http.put(serviceUrl + "api/students/updatestudent/", studentDetails).success(function (response) {

                deferred.resolve(response);

            }).error(function (err, status) {

                deferred.reject(err);
            });
            return deferred.promise;
        }

        var _getStudentDetails = function(studentId)
        {
            //create deferred object
            var deferred = $q.defer();

            //service call
            $http.get(serviceUrl + "api/Students/" + studentId).success(function (response) {

                deferred.resolve(response);
            })
            .error(function (errorMessage, status) {

                deferred.reject(errorMessage);
            });

            return deferred.promise;
        }

        studentServiceFactory.getAllGrades = _getAllGrades;
        studentServiceFactory.saveStudentProfile = _saveStudentProfile;
        studentServiceFactory.getStudentDetails = _getStudentDetails;
        studentServiceFactory.updateStudentProfile = _updateStudentProfile;

        return studentServiceFactory;
    };
})();