ninapp.service('loginService', function loginService($timeout, loginFactory) {
    // factories
    var lf = loginFactory;

    // ajax calls
    function getLoginStatus() {
        // TODO: remove when webmethod in place
        if (lf.username == 'a' && lf.password == 'b') { lf.isLoggedIn = true; };
        console.log('now returning');
        return;

        var req = $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../webServices/loginService.asmx/getLoginStatus",
            data: JSON.stringify({ username: lf.username, password: lf.password }),
            dataType: "json"
        });

        req.done(function (data) {
            lf.isLoggedIn = data.d || false;
            alert(data.d);
        });

        req.fail(function (xhr, status, error) {
            lf.isLoggedIn = false;
            console.log('failed to check login');
        });
    };

    // closures
    return {
        getLoginStatus: function() { getLoginStatus(); }
    };

});