const BASE_PATH = process.env.NEXT_PUBLIC_BASE_PATH_BACK;

export const LOGIN = `${BASE_PATH}/login`;
export const GET_USER_INFORMATIONS = `${BASE_PATH}/users/get-user-by-email`;
export const UPDATE_USER_INFORMATIONS = `${BASE_PATH}/update`;

export const VIACEP = (e: string) => `https://viacep.com.br/ws/${e}/json/`;
