
(function () {
    'use strict';

    angular
    .module('app')
    .controller('StudentListingController', StudentListingController);

    function StudentListingController($scope, $state, $location, DTOptionsBuilder, DTColumnBuilder, toaster, StudentListingService) {

        var vm = this;

        vm.studentList = [];

        vm.dtOptions = DTOptionsBuilder.newOptions()
       .withOption('order', [0, 'asc']);


        // VM methods
        vm.AddStudent = AddStudent;
        vm.editStudent = editStudent;
        vm.deleteStudent = deleteStudent;
        


        Activate();

        function Activate() {
            GetAllStudents();
        }

        function AddStudent() {
            $location.path("/student/-1");
        }

        function GetAllStudents() {
            StudentListingService.getAllStudents().then(function (response) {

                if (response) {
                    vm.studentList = response;
                }
            });
        }

        function editStudent(studentId) {
            
            $location.path("/student/" + studentId);
        }

        function deleteStudent(studentId) {

            //toaster.pop('info', "title", "Student deleted");
            StudentListingService.deleteStudent(studentId).then(function (response) {

                if (response)
                {
                    toaster.success({ title: "Success", body: "Student has been deleted" });
                    GetAllStudents();
                }
            });
        }
    };
})();