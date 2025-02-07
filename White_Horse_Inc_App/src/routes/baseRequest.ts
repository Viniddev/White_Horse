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

export async function fetchLoginInformations( login: string, senha: string ): Promise<retornoLoginComToken> {

  var response: any = await fetch(LOGIN, {
    method: "PUT",
    headers: Headers,
    body: JSON.stringify({ Email: login, Password: senha }),
  })
  .catch(error => console.error("Erro:", error));

  const data: any = await response;
  return data;
}
