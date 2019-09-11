import { DocTypeEnum } from './DocTypeEnum';
import { BirthDocModel } from './BirthDocModel';
import { DeathDocModel } from './DeathDocModel';
import { MarriageDocModel } from './MarriageDocModel';
import { DivorceDocModel } from './DivorceDocModel';
import { NidDocModel } from './NidDocModel';
import { CsoBirthDocComponent } from 'src/app/components/cso/cso-birth-doc/cso-birth-doc.component';
import { CsoDeathDocComponent } from 'src/app/components/cso/cso-death-doc/cso-death-doc.component';
import { CsoMarriageDocComponent } from 'src/app/components/cso/cso-marriage-doc/cso-marriage-doc.component';
import { CsoDivorceDocComponent } from 'src/app/components/cso/cso-divorce-doc/cso-divorce-doc.component';
import { CsoNidDocComponent } from 'src/app/components/cso/cso-nid-doc/cso-nid-doc.component';

export class DocTypeFactory {

    private _docTypes;

    constructor() {

        this._docTypes = [
            {docTypeEnum: DocTypeEnum.BirthDoc, docCode: 'MOICSO001', docName: 'Birth Doc',
            docTypeModel: BirthDocModel, docTypeComponent: CsoBirthDocComponent},
            {docTypeEnum: DocTypeEnum.DeathDoc, docCode: 'MOICSO005', docName: 'Death Doc',
            docTypeModel: DeathDocModel, docTypeComponent: CsoDeathDocComponent},
            {docTypeEnum: DocTypeEnum.MarriageDoc, docCode: 'MOICSO003', docName: 'Marriage Doc',
            docTypeModel: MarriageDocModel, docTypeComponent: CsoMarriageDocComponent},
            {docTypeEnum: DocTypeEnum.DivorceDoc, docCode: 'MOICSO004', docName: 'DivorceDoc',
            docTypeModel: DivorceDocModel, docTypeComponent: CsoDivorceDocComponent},
            {docTypeEnum: DocTypeEnum.NidDoc, docCode: 'MOICSO002', docName: 'Nid Doc',
            docTypeModel: NidDocModel, docTypeComponent: CsoNidDocComponent},
        ];
    }
    // This method is used to create an instance of a generic type by passing in the type itself
    create<T>(type: (new () => T)): T {
        return new type();
    }

    createDocModel(docTypeEnum: DocTypeEnum) {
        return new (this._docTypes.find( a => a.docTypeEnum === docTypeEnum ).docTypeModel);
    }

    getComponentByDocType(docTypeEnum: DocTypeEnum) {
        return this._docTypes.find( a => a.docTypeEnum === docTypeEnum ).docTypeComponent;
    }

    getDocName(docTypeEnum: DocTypeEnum) {
        return this._docTypes.find( a => a.docTypeEnum === docTypeEnum ).docName;
    }

    getDocCode(docTypeEnum: DocTypeEnum) {
        return this._docTypes.find( a => a.docTypeEnum === docTypeEnum ).docCode;
    }
}
