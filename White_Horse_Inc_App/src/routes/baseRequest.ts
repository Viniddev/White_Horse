import { LoginReq } from "@/@types/req";
import { retornoLoginComToken } from "@/@types/resp";
import { LOGIN } from "@/utils/backEndUrls/urls";
import GetHeader from "./GetRequestHeader";


export async function fetchLoginInformations( loginInformations: LoginReq): Promise<retornoLoginComToken> {

  var response: any = await fetch(LOGIN, {
    method: "PUT",
    headers: GetHeader(),
    body: JSON.stringify(loginInformations),
  });

  const data: Promise<retornoLoginComToken> = await response.json();
  return data;
}
