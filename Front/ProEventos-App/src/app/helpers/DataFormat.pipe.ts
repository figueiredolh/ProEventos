import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

import { Constants } from '../utils/constants';

@Pipe({
  name: 'DataFormat'
})
export class DataFormatPipe extends DatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return super.transform(value, Constants.DATE_TIME_FMT); //super references to DatePipe class
  }

}
