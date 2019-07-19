import { ValidatorFn, FormGroup, ValidationErrors } from "@angular/forms";

export const sameNameValidator: ValidatorFn = (control: FormGroup): ValidationErrors | null => {
  const firstName = control.get('firstName');
  const fatherName = control.get('fatherName');

  return firstName && fatherName && firstName.value === fatherName.value ? { 'sameName': true } : null;
};
