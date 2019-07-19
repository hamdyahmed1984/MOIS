"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function forbiddenNameValidator(nameRe) {
    return function (control) {
        var forbidden = nameRe.test(control.value);
        return forbidden ? { 'forbiddenName': { value: control.value } } : null;
    };
}
exports.forbiddenNameValidator = forbiddenNameValidator;
//# sourceMappingURL=forbidden-name.js.map