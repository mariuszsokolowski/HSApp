<template>
  <div>
    <v-dialog v-model="dialog" persistent max-width="600px">
      <v-card>
        <div class="headline orange lighten-2 d-flex justify-end">
          <div class="flex-grow-1"></div>
          <v-btn text @click="close">X</v-btn>
        </div>
        <div class="text-center">
          <video id="video" width="300" height="200" ref="video"></video>
        </div>
      </v-card>
    </v-dialog>
  </div>
</template>

<script type="module">
import { BrowserQRCodeReader, BrowserBarcodeReader } from "@zxing/library";
var codeReader = new BrowserQRCodeReader();
var barCodeReader = new BrowserBarcodeReader();
export default {
  data() {
    return {
      dialog: true,
      scanResult: "",
      videoDevices: []
    };
  },
  methods: {
    readCode(code) {
      this.scanResult = code;
      if (this.scanResult.length > 0) this.successScan();
    },
    initReader() {
      codeReader
        .listVideoInputDevices()
        .then(videoInputDevices => {
          videoInputDevices.forEach(device =>
            this.videoDevices.push(device.deviceId)
          );
        })
        .catch(err => console.error(err));

      const firstDeviceId = this.videoDevices[0];
      codeReader
        .decodeFromInputVideoDevice(firstDeviceId, "video")
        .then(result => this.readCode(result.text))
        .catch(err => console.error(err));

      barCodeReader
        .decodeFromInputVideoDevice(firstDeviceId, "video")
        .then(result => this.readCode(result.text))
        .catch(err => console.error(err));
    },
    close() {
      this.stopCamera();
      this.$emit("close"), (this.dialog = false);
    },
    successScan() {
      this.stopCamera();
      this.$emit("successScan", this.scanResult);
      this.dialog = false;
    },
    stopCamera() {
      this.$refs.video.pause();
      codeReader.videoElement = null;
      codeReader.stream = null;
      barCodeReader.stream = null;

      barCodeReader.videoElement = null;
      console.log(codeReader);
    }
  },
  mounted() {
    this.initReader();
    console.log(codeReader);
  },
  destroyed() {
    console.log("destroy");
  }
};
</script>

<style lang="scss" scoped>
</style>