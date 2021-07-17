var fs = require('fs');
var path = require('path');
var postcss = require('postcss');

module.exports = postcss.plugin('postcss-awsm-css', function (options) {
  options = options || {};
  var theme = options.theme || 'white';
  var sealed = options.sealed || false;

  var filenameThemed = theme ? ('awsm_theme_' + theme) : 'awsm';
  var filenameSealed = sealed ? [filenameThemed, 'sealed'].join(theme ? '._' : '_') : filenameThemed;
  var filename = filenameSealed + '.min.css';

  return function(css) {
    return new Promise(function(resolve) {
      var filepath = path.join(__dirname, 'dist', filename);
      var filecontent = fs.readFileSync(filepath, 'utf8');

      css.prepend(filecontent);

      resolve();
    })
  };
});
