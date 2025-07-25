
let scene, camera, renderer, airplane;

function init() {
  scene = new THREE.Scene();
  camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
  renderer = new THREE.WebGLRenderer({
    canvas: document.getElementById("canvas"),
    antialias: true
  });
  renderer.setSize(window.innerWidth, window.innerHeight);

  // Crea l'aereo
  const geometry = new THREE.BoxGeometry(1, 1, 1);
  const material = new THREE.MeshBasicMaterial({ color: 0xffffff });
  airplane = new THREE.Mesh(geometry, material);
  scene.add(airplane);

  // Crea il terreno
  const terrainGeometry = new THREE.PlaneGeometry(100, 100);
  const terrainMaterial = new THREE.MeshBasicMaterial({ color: 0x964B00 });
  const terrain = new THREE.Mesh(terrainGeometry, terrainMaterial);
  terrain.rotation.x = -Math.PI / 2;
  scene.add(terrain);

  camera.position.z = 5;

  animate();
}

function animate() {
  requestAnimationFrame(animate);
  airplane.rotation.x += 0.01;
  airplane.rotation.y += 0.01;
  renderer.render(scene, camera);
}

init();

// Controlli
document.addEventListener("keydown", (event) => {
  switch (event.key) {
    case "ArrowUp":
      airplane.position.y += 0.1;
      break;
    case "ArrowDown":
      airplane.position.y -= 0.1;
      break;
    case "ArrowLeft":
      airplane.rotation.y -= 0.1;
      break;
    case "ArrowRight":
      airplane.rotation.y += 0.1;
      break;
  }
});
