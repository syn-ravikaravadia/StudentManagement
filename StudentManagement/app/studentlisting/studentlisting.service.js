(function () {
    'use strict'

    angular
    .module('app')
    .factory('StudentListingService', StudentListingService);

    function StudentListingService($http, $q, ApiConfiguration) {

        var serviceUrl = ApiConfiguration.serviceUrl;
        var studentListingServiceFactory = {};


        var _getAllStudents = function () {

            //create deferred object
            var deferred = $q.defer();

            //service call
            $http.get(serviceUrl + "api/Students").success(function (response) {

                deferred.resolve(response);
            })
            .error(function (errorMessage, status) {

                deferred.reject(errorMessage);
            });

            return deferred.promise;
        }

        var _deleteStudent = function(studentId)
        {
            var deferred = $q.defer();

            //service call
            $http.delete(serviceUrl + "api/Students/"+ studentId).success(function (response) {

                deferred.resolve(response);
            })
            .error(function (errorMessage, status) {

                deferred.reject(errorMessage);
            });

            return deferred.promise;

        }

        studentListingServiceFactory.getAllStudents = _getAllStudents;
        studentListingServiceFactory.deleteStudent = _deleteStudent;

        return studentListingServiceFactory;
    };
})();