export interface SaveGroup {
    id: number;
    name: string;
    companyId: number;
    dbConfigId: number;
    dataFileTemplates: any;
    isActive: boolean;
    appUsers: number[];
}