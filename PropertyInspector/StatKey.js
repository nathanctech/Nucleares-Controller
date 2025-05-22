function resetCounter() {
    var payload = {};
    payload.property_inspector = 'setStat';
    sendPayloadToPlugin(payload);
}