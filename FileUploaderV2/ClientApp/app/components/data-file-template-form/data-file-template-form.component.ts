import { Component, OnInit, Output } from '@angular/core';
import { CompanyService } from '../../services/company.service';
import { FeatureService } from '../../services/feature.service';

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
    features: any[];

    /** data-file-template-form ctor */
    constructor(private companyService: CompanyService,
        private featureService: FeatureService) {

    }

    ngOnInit() {
        this.companyService.getCompanies()
            .subscribe((companies: any) => {
                this.companies = companies
            });
        this.featureService.getFeatures()
            .subscribe(features => this.features = features);
    }

    onCompanyChange() {
        var selectedCompany = this.companies.find(c => c.id == this.dataFileTemplate.company);
        this.groups = selectedCompany ? selectedCompany.group : [];
    }
}