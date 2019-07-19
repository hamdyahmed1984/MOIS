"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.sameNameValidator = function (control) {
    var firstName = control.get('firstName');
    var fatherName = control.get('fatherName');
    return firstName && fatherName && firstName.value === fatherName.value ? { 'sameName': true } : null;
};
//# sourceMappingURL=same-name.js.map