import { ProductCardInformations, Topico } from "@/@types/components"

export const products: Array<ProductCardInformations> = [
  {
    title: "Desenvolvimento Web Full-Stack",
    subtitle: "Domine front-end e back-end por apenas R$ 450",
    description: "Curso completo cobrindo React, Next.js, Node.js e bancos de dados para construir aplicações full-stack.",
    link: "https://vtricks.in/lms/public/frontend/infixlmstheme/img/blog/full-stack-web-development.jpg",
    price: 450,
    topic: 1
  },
  {
    title: "Inteligência Artificial e Machine Learning",
    subtitle: "Aprenda técnicas avançadas de IA por apenas R$ 950",
    description: "Explore aprendizado profundo, redes neurais e soluções baseadas em IA com projetos práticos.",
    link: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTkUmjc10OK_06y5eOynvj_EmBoJkAW7wHzPQ&s",
    price: 950,
    topic: 4
  },
  {
    title: "Fundamentos de Cibersegurança",
    subtitle: "Proteja sistemas e redes por apenas R$ 150",
    description: "Aprimore seus conhecimentos em hacking ético, testes de penetração e melhores práticas de segurança cibernética.",
    link: "https://media.licdn.com/dms/image/v2/D4D12AQGai1fk9P1hTw/article-cover_image-shrink_720_1280/article-cover_image-shrink_720_1280/0/1714033756274?e=2147483647&v=beta&t=cIpYSyiO-20JIkPlXkQ9BxTPow9JPuiMs0Bq3X39z38",
    price: 150,
    topic: 6
  },
  {
    title: "Computação em Nuvem com AWS",
    subtitle: "Domine infraestrutura em nuvem por apenas R$ 1600",
    description: "Aprenda sobre os serviços da AWS, estratégias de implantação e segurança na nuvem com exemplos do mundo real.",
    link: "https://images.squarespace-cdn.com/content/v1/60cfd646701da4034512a1c5/1654217981309-RTSZMBJWA9YJ5V32UN8R/AWS-Cloud.png",
    price: 1600,
    topic: 5
  },
  {
    title: "Ciência de Dados e Análise",
    subtitle: "Extraia insights de dados por apenas R$ 1400",
    description: "Analise dados, construa modelos preditivos e utilize Python para tomadas de decisão baseadas em dados.",
    link: "https://cdn.analyticsvidhya.com/wp-content/uploads/2023/05/18141-scaled.jpg",
    price: 1400,
    topic: 3
  },
  {
    title: "Desenvolvimento de Aplicativos Mobile",
    subtitle: "Crie apps para iOS e Android por apenas R$ 780",
    description: "Aprenda React Native e Flutter para desenvolver aplicativos móveis de alto desempenho.",
    link: "https://www.techmango.net/wp-content/uploads/2022/04/mobile-app-development.png",
    price: 780,
    topic: 2
  },
];


export const TopicosDeDesenvolvimento: Array<Topico> = [
  { name: "Desenvolvimento Web", code: 1 },
  { name: "Desenvolvimento Mobile", code: 2 },
  { name: "Analise de dados", code: 3 },
  { name: "Machine Learning", code: 4 },
  { name: "Cloud Computing", code: 5 },
  { name: "Segurança da informação", code: 6 },
];
