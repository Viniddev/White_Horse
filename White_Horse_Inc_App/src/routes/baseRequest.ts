import { LoginReq } from "@/@types/req";
import { retornoLoginComToken } from "@/@types/resp";
import { LOGIN } from "@/utils/backEndUrls/urls";

const token =
  typeof window !== "undefined" ? sessionStorage.getItem("key") : null;

const Headers: Record<string, string> = {
  "Content-Type": "application/json",
};

if (token) {
  Headers["Authorization"] = `Bearer ${token}`;
}

export async function fetchLoginInformations( loginInformations: LoginReq): Promise<retornoLoginComToken> {

  var response: any = await fetch(LOGIN, {
    method: "PUT",
    headers: Headers,
    body: JSON.stringify(loginInformations),
  });

  const data: Promise<retornoLoginComToken> = await response.json();
  return data;
}
