import "../../styles/globals.scss";
import "./main.scss";
import React from "react";
import { IPostsInformations } from "@/@types/IPostsInformations";
import { Toast } from "primereact/toast";
import useGetAllPosts from "@/hooks/useGetAllPosts";
import MensagemAlerta from "../AlertaPosts/mensagemAlerta";
import { TiposAlerta } from "@/utils/Enums/tipoAlerta";

import Post from "../posts/estruturaPosts";

export default function Main() {
  
  const { 
    loading, 
    posts, 
    toast 
  } = useGetAllPosts();

  return (
    <main className="principalSection">
      <Toast ref={toast} />
      <div className="flexRow conteinerGeralPosts">
        <div className="flexColumn postsList">
          {loading ? (
            <MensagemAlerta
              mensagem="Carregando posts..."
              type={TiposAlerta.Buscando}
            />
          ) : posts.length === 0 ? (
            <MensagemAlerta
              mensagem="Nenhum post encontrado."
              type={TiposAlerta.ListaVazia}
            />
          ) : (
            <>
              {posts.map((element: IPostsInformations, id: number) => (
                <div className="wrapper" key={id}>
                  <Post element={element} />
                </div>
              ))}
            </>
          )}
        </div>
      </div>
    </main>
  );
}
