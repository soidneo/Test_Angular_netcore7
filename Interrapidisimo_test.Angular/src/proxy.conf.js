const PROXY_CONFIG = [
  {
    context: [
      "/studentList",
    ],
    //target: "https://localhost:5001",
    target: "http://localhost:57678/students",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
