ninapp.service('courseService', function loginService(courseFactory) {
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
            cf.courses = data.d || [];
            alert(data.d);
        });

        req.fail(function (xhr, status, error) {
            cf.courses = [];
            console.log('failed to fetch all courses');
        });
    };

    // closures
    return {
        getAllCourses: function() { getAllCourses(); }
    };

});