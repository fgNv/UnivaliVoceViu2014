var AuthenticateRequest = function () {
    this.Username = "";
    this.Password = "";
    this.RememberMe = false;

    var self = this;

    this.Validate = function () {

        var errors = [];

        if (!self.Username)
            errors.push("Deve-se informar o usuário");

        if (!self.Password)
            errors.push("Deve-se informar a senha");

        return errors;
    };
};