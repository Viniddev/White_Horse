
export default function GetHeader(){
    const token =
      typeof window !== "undefined" ? sessionStorage.getItem("Token") : null;

    const Headers: Record<string, string> = {
      "Content-Type": "application/json",
    };

    if (token) {
      Headers["Authorization"] = `Bearer ${token}`;
    }

    return Headers;
}