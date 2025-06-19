const BASE_PATH = "https://localhost:7223/api/v1";

export const LOGIN = `${BASE_PATH}/login`;
export const GET_USER_INFORMATIONS = `${BASE_PATH}/GetUserProfileInformations`;
export const UPDATE_USER_INFORMATIONS = `${BASE_PATH}/update`;

export const VIACEP = (e: string) => `https://viacep.com.br/ws/${e}/json/`;