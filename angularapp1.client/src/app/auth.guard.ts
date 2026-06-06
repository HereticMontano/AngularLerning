import { inject } from '@angular/core';
import { Router, CanActivateFn } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const token = localStorage.getItem('jwt_token');

  if (token) {
    // Aquí se podría decodificar el token para comprobar si expiró, pero
    // para una app sencilla comprobamos al menos que exista. Si el servidor 
    // rechaza la llamada, se puede capturar el 401 en el interceptor.
    return true;
  } else {
    // Si no hay token, redirigir al login
    router.navigate(['/login']);
    return false;
  }
};
