var gulp = require('gulp');
var browserify = require('browserify');
var babelify = require('babelify');
var rename = require('gulp-rename');
var source = require('vinyl-source-stream');
var less = require('gulp-less');
var path = require('path');

gulp.task('less', function () {
  return gulp.src('./App/styles/**/*.less')
    .pipe(less({
      paths: [ path.join(__dirname, 'less', 'includes') ]
    }))
    .pipe(gulp.dest('./public/css'));
});

gulp.task('build', ['less'], function() {
  var entryFile = './App/index.jsx';
  var bundler = browserify(entryFile, { extensions: [ ".js", ".jsx" ] });

  bundler.transform(babelify);

  var stream = bundler.bundle();
  stream.on('error', function (err) {
    console.error(err.toString());
  });

  stream
    .pipe(source(entryFile))
    .pipe(rename('index.js'))
    .pipe(gulp.dest('public/'));
});

gulp.task('watch', function() {
  gulp.watch(['./jsx/**/*'], ['scripts']);
});
