import "../../styles/globals.scss";
import "./main.scss";
import React, { useState } from "react";
import { IPostsInformations } from "@/@types/IPostsInformations";
import { Toast } from "primereact/toast";
import useGetAllPosts from "@/hooks/useGetAllPosts";
import MensagemAlerta from "../alertaPosts/mensagemAlerta";
import { TiposAlerta } from "@/utils/Enums/tipoAlerta";

import Post from "../posts/estruturaPosts";
import ModalCriacaoPosts from "../modalCriacaoPosts/modal";
import { SpeedDial } from "primereact/speeddial";

export default function Main() {
  
  const { loading, posts, toast, visible, setVisible, items } = useGetAllPosts();
  
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

      <div className="fixed-speed-dial">
        <SpeedDial
          model={items}
          direction="up"
          buttonClassName="p-button-help"
        />
      </div>

      <ModalCriacaoPosts visible={visible} setVisible={setVisible} />
    </main>
  );
}
