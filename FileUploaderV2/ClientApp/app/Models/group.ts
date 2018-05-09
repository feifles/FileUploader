import { KeyValuePair } from "./KeyValuePair";

export interface Group {
    id: number;
    name: string;
    company: KeyValuePair;
    dbConfig: KeyValuePair;
    dataFileTemplates: any;
    isActive: boolean;
    appUsers: KeyValuePair[];
    lastUpdate: string;
}

