ninapp.service('courseService', function loginService(courseFactory, $timeout) {
    // factories
    var cf = courseFactory;

    // ajax calls
    function getAllCourses() {
        var req = $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../webServices/courseService.asmx/getAllCourses",
            dataType: "json"
        });

        req.done(function (data) {
            $timeout( function() { cf.courses = data.d || [] }, 0);
            console.log(data.d);
        });

        req.fail(function (xhr, status, error) {
            cf.courses = [];
            console.log('failed to fetch all courses');
        });
    };

    function getCourse(id) {
        var req = $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../webServices/courseService.asmx/getCourse",
            data: JSON.stringify({ id: id }),
            dataType: "json"
        });

        req.done(function (data) {
            $timeout(function() { cf.subscriptionCourse = data.d || []; }, 0);
        });

        req.fail(function (xhr, status, error) {
            cf.courses = [];
            console.log('failed to fetch all courses');
        });
    };


    // closures
    return {
        getAllCourses: function() { getAllCourses(); },
        getCourse: function(id) { getCourse(id); }
    };

});