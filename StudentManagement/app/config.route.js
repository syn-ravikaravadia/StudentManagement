(function () {

    'use strict';

    angular
        .module('app')
        .config(routeConfig)

    function routeConfig($stateProvider, $urlRouterProvider) {
        //$stateProvider
        //.state('student', {
        //    url: '/student',
        //    templateUrl: 'app/student/student.tmpl.html',
        //    controller: 'StudentController as vm',
        //    //resolve: { $state: '$state' }
        //})

        $stateProvider
        .state('student.studentlisting', {
            url: '/studentlisting',
            templateUrl: 'app/studentlisting/studentlisting.tmpl.html',
            controller: 'StudentListingController as vm',
            //resolve: { $state: '$state' }
        });
    }

})();