
export enum CsoWizardStepEnum {
  // the name of the enum element should be "requester" and not "Requester"
  // because we use it in routing when we redirect to the first invalid step
  // and this is for all elements of te wizard
  Requester = 'requester',
  AddressGroup = 'address',
  CsoDocs = 'docs',
  CsoDocsDetails = 'docs-details',
  Confirm = 'confirm'
}

