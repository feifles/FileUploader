﻿import * as Raven from 'raven-js';
import { ErrorHandler, Inject, NgZone, isDevMode } from '@angular/core';
import { ToastyService } from 'ng2-toasty';

export class AppErrorHandler implements ErrorHandler {

    constructor(
        @Inject(NgZone) private ngZone: NgZone,
        @Inject(ToastyService) private toastyService: ToastyService) {

    }

    handleError(error: any): void {

        if (!isDevMode)
            Raven.captureException(error.originalError || error);
        else
            throw error;

        this.ngZone.run(() => {
            this.toastyService.error({
                title: 'Erro',
                msg: 'Um erro inesperado ocorreu.',
                theme: 'bootstrap',
                showClose: true,
                timeout: 5000
            });
        });
    }
}
