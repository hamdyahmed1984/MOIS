import { DocTypeEnum } from './DocTypeEnum';
import { DocTypeFactory } from './DocTypeFactory';

export class DocTypesModel {

    private readonly _docs = [];
    private _currentDocIndex = -1;

    constructor() { }

    // If we want to get all docs and prevent changes to our internal array from outside world
    GetDocs() {
        const readOnlyDocs: ReadonlyArray<any> = this._docs;
        return readOnlyDocs;
    }

    adjustDocsCountOfType(docTypeEnum: DocTypeEnum, newCount: number) {
        const currentCount = this.getDocsCountOfType(docTypeEnum);
        const docFactory = new DocTypeFactory();
        if (newCount > currentCount) {
            for (let i = currentCount; i < newCount; i++) {
                this.addDoc(docFactory.createDocModel(docTypeEnum), docFactory.getComponentByDocType(docTypeEnum), docTypeEnum);
            }
        } else if (newCount < currentCount) {
            for (let i = currentCount; i > newCount; i--) {
                this.removeLastDocOfType(docTypeEnum);
            }
        }
        this.sortDocs();
    }

    getDocsCountOfType(docTypeEnum: DocTypeEnum) {
        return this._docs.filter((a) => a.docTypeEnum === docTypeEnum).length;
    }

    getCurrentDoc() {
        if (this._currentDocIndex >= this._docs.length) {
            this._currentDocIndex = this._docs.length - 1; // Reset current index to the last doc in the array or -1 if the length is 0
        }

        return this._currentDocIndex === -1 ? this._docs[++this._currentDocIndex] : this._docs[this._currentDocIndex];
    }

    getNextDoc() {
        return this.hasNext() ? this._docs[++this._currentDocIndex] : undefined;
    }

    getPrevDoc() {
        return this.hasPrev() ? this._docs[--this._currentDocIndex] : undefined;
    }

    hasNext() {
        return this._docs.length > 0 && this._currentDocIndex < this._docs.length - 1;
    }

    hasPrev() {
        return this._docs.length > 0 && this._currentDocIndex > 0;
    }

    resetCurrentIndex() {
        this._currentDocIndex = -1;
    }

    getCurrentDocIndex = () => this._currentDocIndex;

    getTotalDocsCount = () => this._docs.length;

    private addDoc(doc: any, docTypeComponent: any, docTypeEnum: DocTypeEnum) {
        this._docs.push({ doc: doc, docTypeComponent: docTypeComponent, docTypeEnum: docTypeEnum, isAgreed: false });
        // this.sortDocs();
    }

    // Removes the last document of a specific type from the array
    private removeLastDocOfType(docTypeEnum: DocTypeEnum) {
        for (let i = this._docs.length - 1; i >= 0; i--) {
            if (this._docs[i].docTypeEnum === docTypeEnum) {
                this._docs.splice(i, 1);
                break;
            }
        }
    }

    private sortDocs() {
        this._docs.sort((a, b) => a.docTypeEnum - b.docTypeEnum);
    }
}
