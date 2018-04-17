import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { CompanyFormComponent } from './components/company-form/company-form.component';
import { GroupFormComponent } from './components/group-form/group-form.component';
import { DataFileTemplateFormComponent } from './components/data-file-template-form/data-file-template-form.component';
import { CompanyService } from './services/company.service';
import { FeatureService } from './services/feature.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        CompanyFormComponent,
        DataFileTemplateFormComponent,
        GroupFormComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'company/new', component: CompanyFormComponent },
            { path: 'datafiletemplate/new', component: DataFileTemplateFormComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        CompanyService,
        FeatureService
    ]
})
export class AppModuleShared {
}
