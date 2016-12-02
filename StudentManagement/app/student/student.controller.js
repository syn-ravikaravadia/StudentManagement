
(function () {
    'use strict';

    angular
    .module('app')
    .controller('StudentController', StudentController);

    function StudentController($scope, $state, $location, $stateParams, $routeParams, toaster, StudentService) {

        var vm = this;
        vm.studentId = $routeParams.studentId;

        if (vm.studentId > 0)
        {
            vm.isNew = false;
        }
        else
        {
            vm.isNew = true;
        }
        vm.student = {};

        $scope.grades = [];
        $scope.alphabetsRegex = /^[aA-zZ]*$/;
        $scope.maxlength = 15;

        // VM methods
        vm.createNew = createNew;
        vm.SaveStudent = SaveStudent;
        //vm.UpdateStudent = UpdateStudent;

        InitializeDates();
        Activate();

        function InitializeDates() {

            $scope.currentDate = new Date();
            var maxDate = new Date(
                $scope.currentDate.getFullYear() - 1,
                $scope.currentDate.getMonth(),
                $scope.currentDate.getDate());

            $scope.birthdate = maxDate;

            $scope.minDate = new Date(
                $scope.currentDate.getFullYear() - 50,
                $scope.currentDate.getMonth() - 2,
                $scope.currentDate.getDate());

            $scope.maxDate = maxDate;

            
        }

        function Activate() {

            GetAllGrades();

            if (vm.studentId > 0)
            {
                GetStudentDetails(vm.studentId);
                vm.ActionText = "Update";
            }
            else
            {
                vm.createNew();
                vm.ActionText = "Submit";
            }
        }

        function GetAllGrades()
        {
            StudentService.getAllGrades().then(function (response) {
                if (response) {
                    $scope.grades = response;
                    vm.student.GradeId = $scope.grades[0].GradeId;
                }
            });
        }

        function GetStudentDetails(studentId)
        {
            StudentService.getStudentDetails(studentId).then(function (response) {
                
                if(response)
                {
                    vm.student = {
                        StudentId: response.StudentId,
                        FirstName: response.FirstName,
                        LastName: response.LastName,
                        GradeId: response.GradeId,
                        BirthDate: new Date(response.BirthDate)
                    };
                }
            });
        }

        function createNew() {
            vm.student = {
                StudentId: 0,
                FirstName: '',
                LastName: '',
                GradeId: 0,
                BirthDate: $scope.birthdate
            };
        };

        function SaveStudent(studentProfile) {

            if (vm.isNew)
            {
                SubmitStudent(studentProfile);
            }
            else
            {
                UpdateStudent(studentProfile);
            }
        }

        function SubmitStudent(studentProfile)
        {
            StudentService.saveStudentProfile(studentProfile).then(function (response) {

                if (response) {
                    toaster.success({ title: "Success", body: "Student profile saved successfully." });
                    $location.path("/studentlisting");
                }
            });

        }

        function UpdateStudent(studentProfile)
        {
            StudentService.updateStudentProfile(studentProfile).then(function (response) {

                if (response) {
                    toaster.success({ title: "Success", body: "Student profile updated successfully." });
                    $location.path("/studentlisting");
                }
            });
        }

    };
})();