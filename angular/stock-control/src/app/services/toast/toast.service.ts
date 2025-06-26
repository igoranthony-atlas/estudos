import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor() {}

  getToast(){
    return  Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOpen: (toast) => {
      toast.addEventListener('mouseenter', Swal.stopTimer);
      toast.addEventListener('mouseleave', Swal.resumeTimer);
    }
  });
  }
    showSuccess(message: string) {
        this.getToast().fire({
        icon: 'success',
        title: message
        });
    }
    showError(message: string) {
        this.getToast().fire({
        icon: 'error',
        title: message
        });
    }
    //toast de confirmação
    showConfirmation(message: string, confirmButtonText: string = 'Confirmar', cancelButtonText: string = 'Cancelar') {
        return Swal.fire({
            title: 'Confirmação',
            text: message,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: confirmButtonText,
            cancelButtonText: cancelButtonText,
            confirmButtonColor: '#10B981',
            
            cancelButtonColor: '#EF4444',
            iconColor: '#10B981',
        });
    }
}