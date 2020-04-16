import axios from 'axios';

const USER_INFO = 'user';

export class httpClient {
//constructor de la clase
//setea el token si existe a el header de authorization
  constructor() {
    const token = sessionStorage.getItem(USER_INFO) == null ? null: JSON.parse(sessionStorage.getItem(USER_INFO)).token;
    const instance = axios.create({
      headers: !token? {} : { 'Authorization': `Bearer ${token}` }
    });
    this.axiosInstance = instance;
  }

  get(url){
    return this.axiosInstance.get(url)
    .then((resp) => {
      return resp;
    })
    .catch((resp) => {
      if (resp.response !== undefined && resp.response.status == '401') {
        sessionStorage.removeItem(USER_INFO);
      } else {
        return Promise.reject(resp);
      }})
  }

  post(url, formData) {
    return this.axiosInstance.post(url, formData)
    .then((resp) => {
      return resp;
    })
    .catch((resp) => {
      if (resp.response !== undefined && resp.response.status == '401') {
        sessionStorage.removeItem(USER_INFO);
      } else {
        return Promise.reject(resp);
    }})
  }

  setTokenOnLogin = () => {
    const _token = JSON.parse(sessionStorage.getItem(USER_INFO)).token;
    this.axiosInstance.defaults.headers = { 'Authorization': `Bearer ${_token}` };
  }
  clearTokenOnLogout = () => {
    localStorage.removeItem(USER_INFO);
    this.axiosInstance.defaults.headers = {};
  }

 /*funcion que se encarga, de que si existe un token se lo agrega el header de http auth para autenticar la llamada*/
  /*initInterceptors(){
    axios.interceptors.request.use((config)=>{
      const token = this.getToken();
      if(!token){
        config.headers.authorization = `bearer ${token}`;
      }
      return config;
    });
    axios.interceptors.response.use((response) => {
       return response;
    }, (error) => {
       return Promise.reject(error.message);
    });
  }*/
}

const http =  new httpClient();
export default http;
