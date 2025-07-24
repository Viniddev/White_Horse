const BASE_PATH = process.env.NEXT_PUBLIC_BASE_PATH_FRONT;

export const HOME = `${BASE_PATH}`;
export const PROFILE = `${BASE_PATH}/perfil`;
export const LOGIN = `${BASE_PATH}/login`;
export const CADASTRO = `${BASE_PATH}/cadastro`;
export const POSTS = (post: string) => `${BASE_PATH}/post/${post}`;