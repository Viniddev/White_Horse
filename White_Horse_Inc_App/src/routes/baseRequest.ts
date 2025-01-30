import { retornoLoginComToken } from "@/@types/resp";
import { LOGIN } from "@/utils/backEndUrls/urls";



const token: string | null =
  typeof window !== "undefined" ? localStorage.getItem("key") : null;


const Headers = {
  "Content-Type": "application/json",
  Autorization: `Bearer ${token}`,
};


export async function fetchLoginInformations(
  login: string,
  senha: string,
  token: string | number | undefined
): Promise<retornoLoginComToken> {
  if (token == "") {

    var response: any = await fetch(LOGIN, {
      method: "POST",
      headers: Headers,
      body: JSON.stringify({ login: login, password: senha }),
    });

  } else {

    var response: any = await fetch(LOGIN, {
      method: "POST",
      headers: Headers,
      body: JSON.stringify({ login: login, password: senha, token: token }),
    });
    
  }

  const data: retornoLoginComToken = await response.json();
  console.log(data);
  return data;
}
