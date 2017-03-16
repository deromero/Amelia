"use strict";
var UserView = (function () {
    function UserView(id, username, email) {
        this.Id = id;
        this.Username = username;
        this.Email = email;
    }
    return UserView;
}());
exports.UserView = UserView;
