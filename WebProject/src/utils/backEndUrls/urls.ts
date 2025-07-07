const BASE_PATH = process.env.NEXT_PUBLIC_BASE_PATH_BACK;

//register
export const LOGIN = `${BASE_PATH}/login`;
export const REGISTER = `${BASE_PATH}/create-user`;

//users
export const GET_USER_INFORMATIONS = `${BASE_PATH}/users/get-user-by-email`;
export const UPDATE_USER_INFORMATIONS = `${BASE_PATH}/users/update`;

//posts
export const GET_ALL_POSTS = `${BASE_PATH}/posts/get-all`;

//address
export const VIACEP = (e: string) => `https://viacep.com.br/ws/${e}/json/`;
