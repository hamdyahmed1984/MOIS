//export const CsrWizardSteps = {
//  requester: 'requester',
//  address: 'address',
//  doc: 'doc',
//  confirm: 'confirm'
//};

export enum CsrWizardStepEnum {
  Requester = "requester",//the name of the enum element should be "requester" and not "Requester" because we use it in routing when we redirect to the first invalid step and this is for all elements of te wizard
  AddressGroup = "address",
  CsrDocument = "doc",
  Confirm = "confirm"
}

