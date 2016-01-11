ninapp.factory('loginFactory', function () {
    function createChild() {
        return {
            firstName: '',
            lastName: '',
            emailAddress: '',
            phoneOrCell: '',
            fullname: lastname + ' ' + firstname
        };
    };

    // closures
    return {
        username: '',
        password: '',
        isLoggedIn: false,
        userData: { 
            childrenToSubscribe: [],
            allChildren: [],
            addNewChild: false,
            createChild: function() { return createChild(); }
            }
    };

});