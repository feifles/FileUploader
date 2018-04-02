import { Component, OnInit, Output } from '@angular/core';
import { CompanyService } from '../../services/company.service';

@Component({
    selector: 'data-file-template-form',
    templateUrl: './data-file-template-form.component.html',
    styleUrls: ['./data-file-template-form.component.css']
})
/** data-file-template-form component*/
export class DataFileTemplateFormComponent implements OnInit {

    companies: any[];
    dataFileTemplate: any = {};
    groups: any[];

    /** data-file-template-form ctor */
    constructor(private companyService: CompanyService) {

    }

    ngOnInit() {
        this.companyService.getCompanies()
            .subscribe((companies: any) => {
                this.companies = companies
            });
    }

    onCompanyChange() {
        var selectedCompany = this.companies.find(c => c.id == this.dataFileTemplate.company);
        this.groups = selectedCompany ? selectedCompany.group : [];
    }
}