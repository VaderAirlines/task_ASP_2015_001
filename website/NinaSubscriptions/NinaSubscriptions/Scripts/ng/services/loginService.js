ninapp.service('loginService',function loginService($timeout,loginFactory) {
    // factories
    var lf=loginFactory;

    // ajax calls
    function getLoginStatus() {
        var req=$.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../webServices/loginService.asmx/getLoginStatus",
            data: JSON.stringify({ username: lf.username,password: lf.password }),
            dataType: "json",
            async: false
        });

        req.done(function(data) {
            lf.isLoggedIn = data.d || false;
            console.log(data.d);
        });

        req.fail(function(xhr,status,error) {
            lf.isLoggedIn = false;
            console.log(xhr.responseText+'\n'+status+'\n'+error);
        });
    };

    function checkLoginSession() {
        var req=$.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../webServices/loginService.asmx/checkLoginSession",
            //data: JSON.stringify({ username: lf.username, password: lf.password }),
            dataType: "json",
            async: false
        });

        req.done(function(data) {
            $timeout(function() {
                lf.isLoggedIn=data.d.isLoggedIn || false;
                lf.username=data.d.login || '';
            },0);
        });

        req.fail(function(xhr,status,error) {
            $timeout(function() {
                lf.isLoggedIn=false;
                lf.username='';
            },0);

            console.log(xhr.responseText+'\n'+status+'\n'+error);
        });
    };

    // closures
    return {
        getLoginStatus: function() { getLoginStatus(); },
        checkLoginSession: function() { checkLoginSession(); }
    };

});