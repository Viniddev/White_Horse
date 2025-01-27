const BASE_PATH = "http://localhost:5001";

export const LOGIN = `${BASE_PATH}/login`;

export const VIACEP = (e: string) => `https://viacep.com.br/ws/${e}/json/`;