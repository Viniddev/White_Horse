const BASE_PATH = "https://localhost:7156";

export const LOGIN = `${BASE_PATH}/V1/login`;

export const VIACEP = (e: string) => `https://viacep.com.br/ws/${e}/json/`;