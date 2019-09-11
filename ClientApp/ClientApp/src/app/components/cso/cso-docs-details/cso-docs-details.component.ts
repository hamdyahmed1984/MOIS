import { Component, OnInit, ViewChild, ComponentFactoryResolver, ViewContainerRef,
  ComponentRef, ChangeDetectorRef, AfterContentChecked } from '@angular/core';
import { CsoFormDataService } from 'src/app/services/cso-form-data.service';
import { DocTypesModel } from 'src/app/models/Documents/DocTypesModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cso-docs-details',
  templateUrl: './cso-docs-details.component.html',
  styleUrls: ['./cso-docs-details.component.css']
})
export class CsoDocsDetailsComponent implements OnInit, AfterContentChecked {
  @ViewChild('docContainer', { read: ViewContainerRef, static: true }) docContainer: ViewContainerRef;

  // title = 'Docs Details';
  private docTypesModel: DocTypesModel;
  private componentRef: ComponentRef<any>;
  isCurrentDocValid: boolean;

  constructor(private router: Router,
    private changeDetectRef: ChangeDetectorRef,
    private csoFormDataService: CsoFormDataService,
    private componentFactoryResolver: ComponentFactoryResolver) {
    this.docTypesModel = csoFormDataService.getDocTypesModel();
  }

  ngOnInit() {
    // this.docTypesModel.resetCurrentIndex();
    this.goCurrent();
  }

  ngAfterContentChecked() {
    // We have to call changeDetectRef.detectChanges() to avoid ExpressionChangedAfterItHasBeenCheckedError exception
    this.changeDetectRef.detectChanges();
 }

 isValid() {
  this.isCurrentDocValid = this.componentRef.instance.isValid();
  return this.isCurrentDocValid;
}

  loadDoc(docTypeModel: any) {
    const componentFactory = this.componentFactoryResolver.resolveComponentFactory(docTypeModel.docTypeComponent);
    this.docContainer.clear();
    this.componentRef = this.docContainer.createComponent(componentFactory);
    this.componentRef.instance.docTypeModel = docTypeModel;
    // this.componentRef.instance.notifyDocModelChanges.subscribe(data => {
    //   console.log(data);
    // });
  }

  goCurrent() {
    const docTypeModel = this.docTypesModel.getCurrentDoc();
    this.loadDoc(docTypeModel);
  }

  goNext() {
    if (this.docTypesModel.hasNext()) {
      const docTypeModel = this.docTypesModel.getNextDoc();
      this.loadDoc(docTypeModel);
    } else {
      this.csoFormDataService.setDocDetailsModel(this.docTypesModel);
      this.router.navigate(['/cso/confirm']);
    }
  }

  goPrevious() {
    if (this.docTypesModel.hasPrev()) {
      const docTypeModel = this.docTypesModel.getPrevDoc();
      this.loadDoc(docTypeModel);
    } else {
      this.router.navigate(['/cso/docs']);
    }
  }
}
