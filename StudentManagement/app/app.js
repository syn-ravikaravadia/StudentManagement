
(function () {
    'use strict';
    //'ui.bootstrap'
    //'datatables'

    angular
    .module('app', ['ngRoute', 'ui.router', 'datatables','toaster','ngAnimate'])
    .constant('ApiConfiguration', {
        'serviceUrl': 'http://localhost:51272/'
    })
    .config(function ($routeProvider, $urlRouterProvider) {

        $routeProvider
        .when('/student/:studentId', {
            templateUrl: 'app/student/student.tmpl.html',
            controller: 'StudentController as vm'

        })
        .when('/studentlisting', {
            templateUrl: 'app/studentlisting/studentlisting.tmpl.html',
            controller: 'StudentListingController as vm'
        })
        .otherwise({ redirectTo: '/studentlisting' });
    });
})();

